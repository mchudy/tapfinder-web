$target = $args[0]
$rest = $args[1..$args.Length]
if ([String]::IsNullOrEmpty($target)) {
    $target = "Default"
}
& ".\.nuget\nuget.exe" restore
& ".\packages\FAKE.4.25.4\tools\Fake.exe" "build.fsx" ("target=" + $target) $rest