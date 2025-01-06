# Central Package Management (CPM) Demo

This solution demonstrates the use of Central Package Management (CPM) in a .NET solution with multiple projects targeting different .NET versions and showcasing version override capabilities.

## What is Central Package Management?

Central Package Management (CPM) is a feature in .NET that allows you to manage NuGet package versions at the solution level, rather than at the individual project level. This approach offers several benefits:

1. Consistency: Ensures all projects use the same version of a given package.
2. Simplified maintenance: Update package versions in one place instead of in each project file.
3. Flexibility: Allows for different versions based on target frameworks when needed.

## Solution Structure

This solution contains three projects:

1. **Project1**: Targets .NET 8.0
   - Uses Newtonsoft.Json (13.0.3)
   - Uses FluentValidation (11.11.0)

2. **Project1_Net7**: Targets .NET 7.0
   - Uses Newtonsoft.Json (13.0.2)
   - Uses FluentValidation (11.8.0)

3. **Project1_OverrideVersion**: Targets .NET 8.0
   - Demonstrates how to override centrally managed package versions
   - Uses custom versions of Newtonsoft.Json and FluentValidation

## How CPM is Implemented

The central configuration for package versions is defined in the `Directory.Packages.props` file at the root of the solution. This file specifies:

- The versions of packages to use for different target frameworks.
- Global package references that apply to all projects.

### Key Points:

- The `ManagePackageVersionsCentrally` property is set to `true` to enable CPM.
- Package versions are specified using `<PackageVersion>` elements.
- Conditional ItemGroups are used to specify different versions for different target frameworks.
- Version overrides are demonstrated in the Project1_OverrideVersion project.  

You can disable this feature by setting the MSBuild property CentralPackageVersionOverrideEnabled to false in a project or in a Directory.Packages.props or Directory.Build.props import file:
```xml
<PropertyGroup>
  <CentralPackageVersionOverrideEnabled>false</CentralPackageVersionOverrideEnabled>
</PropertyGroup>
```

## Project Files

The individual project files (`*.csproj`) typically don't specify package versions when using CPM. They include `<PackageReference>` elements without version attributes. However, the Project1_OverrideVersion project demonstrates how to override these centrally managed versions when necessary.

## Benefits Demonstrated

1. **Version Consistency**: Projects use the same version of packages for their respective target frameworks.
2. **Framework-Specific Versions**: Different versions of packages are used for .NET 7.0 and .NET 8.0 where appropriate.
3. **Centralized Updates**: Package versions can be updated in one place (`Directory.Packages.props`) instead of in each project file.
4. **Flexibility**: The ability to override versions in specific projects when needed, as shown in Project1_OverrideVersion.

## Getting Started

1. Clone this repository.
2. Open the solution in Visual Studio or your preferred IDE.
3. Build the solution to restore packages and ensure everything is set up correctly.
4. Explore the different projects to see how CPM is implemented and how version overrides work.

## Further Reading

- [Central Package Management (CPM) in .NET](https://learn.microsoft.com/en-us/nuget/consume-packages/central-package-management)
- [NuGet PackageReference format](https://learn.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files)