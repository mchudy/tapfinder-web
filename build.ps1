$target = $args[0]
$rest = $args[1..$args.Length]
if ([String]::IsNullOrEmpty($target)) {
    $target = "Default"
}
$fakeFolder = Get-ChildItem .\packages\ | ?{ $_.PSIsContainer } | Sort name | Where-Object {$_.name -like "FAKE*"}
& ".\.nuget\nuget.exe" restore
& ".\packages\$fakeFolder\tools\Fake.exe" "build.fsx" ("target=" + $target) $rest