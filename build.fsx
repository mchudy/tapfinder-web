#r @"packages/FAKE.4.25.4/tools/FakeLib.dll"

open Fake
open Fake.Testing.XUnit2

let joinPaths a b = System.IO.Path.Combine(a, b)
let fullPath a = System.IO.Path.GetFullPath(a)

let deployDir = "./deploy"
let buildDir = "./build"
let testDir   = "./test"

let webConfig = "src/PubApp.Web/Web.config"
let releaseWebConfig = "src/PubApp.Web/Web.Release.config"
let migrationsAppConfig = "src/PubApp.Migrations/App.config"
let transformedAppConfig = buildDir + "/PubApp.Migrations.exe.config"
let transformedConfig = buildDir + "/Web.config"
let defaultConnectionString = "DbConnection"

let migrationsProgram = buildDir + "/PubApp.Migrations.exe"

let awsDeploy = findToolInSubPath "awsDeploy.bat" "tools"
let cttTool = findToolInSubPath "ctt.exe" "tools"
let xunitTool = findToolInSubPath "xunit.console.exe" "packages"

let deploymentMisc = [ "appspec.yml"; transformedConfig ]

let exec program args =
    directExec (fun si ->
        si.FileName <- program
        si.Arguments <- args)

let transformConfig source transformation destination = 
    let args =
        sprintf """s:"%s" t:"%s" d:"%s" """
            (fullPath source) (fullPath transformation) (fullPath destination)
    let result = exec cttTool args
    if not result then failwith "Cannot transform Web.config"

Target "Clean" (fun _ ->
    CleanDirs [buildDir; testDir]
)

Target "BuildTests" (fun _ -> 
    !! "tests/**/*.csproj"
        |> MSBuildRelease testDir "Build"
        |> Log "TestBuild-Output: "
)

Target "BuildApp" (fun _ ->
    !! "src/**/*.csproj"
        |> MSBuildRelease buildDir "Build"
        |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->
      !! (testDir + "/PubApp.*Tests.dll")
        |> xUnit2 (fun p -> 
            {p with 
                ShadowCopy = false;
                HtmlOutputPath = Some (testDir @@ "testResults.html");
                ToolPath = xunitTool;
            })
)

Target "TransformConfig"(fun _ ->
    trace "Transforming Web.config"
    transformConfig webConfig releaseWebConfig transformedConfig

    trace "Transforming App.config for migrations"
    transformConfig migrationsAppConfig releaseWebConfig transformedAppConfig
)

Target "Migrate" (fun _ ->
    trace "Running migrations"
    let result = exec migrationsProgram ""
    if not result then failwith "Error running migrations"
)

Target "Deploy" (fun _ -> 
    CleanDir deployDir
    ensureDirectory deployDir

    trace "Copying site files"
    CopyRecursive (joinPaths buildDir "_PublishedWebsites/PubApp.Web") deployDir true |> ignore

    trace "Copying tools and misc files"
    deploymentMisc  |> CopyTo deployDir

    trace "Running AWS deployment script"
    let result = exec awsDeploy ""
    if not result then failwith "Could not deploy to AWS"
)

Target "Default" DoNothing

"Clean"
    ==> "BuildApp"
    ==> "BuildTests"
    ==> "Test"
    =?> ("TransformConfig", hasBuildParam "prod")
    ==> "Migrate"

"Test"
    ==> "TransformConfig" 
    ==> "Deploy"

"Test" ==> "Default"

RunTargetOrDefault "Default"