#r @"packages/FAKE.4.25.4/tools/FakeLib.dll"
open Fake

Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)

RunTargetOrDefault "Default"