# Unity NuGet

_Note 1: These steps only tested in Macos environment_\
_Note 2: This is based on https://medium.com/@alexandredemersroberge/use-nuget-packages-with-unity-25b8525f628_

Configuration steps:
1. Check Mono installation (eg. type in Terminal `mono --version`)
2. Open Rider and select creating new Project
3. Select `Class Library` (under `.NET Framework`)
4. Edit solution name field
5. Edit solution directory field by choosing Unity project root folder (Rider will create project root folder by itself)
6. Edit framework field and choose `.Net Framework v4.8`
7. Hit `Create`
8. [macos] If project has errors related to missing `.Net Framework`, download it from Mono (https://www.mono-project.com/download/stable/). Homebrew will not help
9. Unload the project (Right click on project in Explorer -> Unload Project)
10. Double click on project in Explorer to modify its content
11. To the bottom (right before `</Project>`) add following:
    ```
    <!-- Move the DLL to the Unity project. -->
    <Target Name="AfterBuild">
        <PropertyGroup>
            <TargetDir>..\..\Assets\Plugins\$(AssemblyName)\Resources</TargetDir>
        </PropertyGroup>
        <ItemGroup>
            <SourceDir Include="bin\Debug\**\*.*" Condition="'$(Configuration)' == 'Debug'"/>
            <SourceDir Include="bin\Release\**\*.*" Condition="'$(Configuration)' == 'Release'"/>
        </ItemGroup>
        <Copy SourceFiles="@(SourceDir)" DestinationFolder="$(TargetDir)" SkipUnchangedFiles="true"/>
    </Target>
    ```
12. Load the project (Right click on project in Explorer -> Load Project)
13. Install desired NuGet package
14. Select `Debug` or `Release` build configuration
15. Build solution (hit `Build Solution (⌘F9)` button)
16. After successful build you can find newly created dll at `{UnityProject}/Assets/Plugins/{SolutionName}/Resources`