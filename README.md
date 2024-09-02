## Introduction

In this lesson, you will learn how to create `Blazor Server` project from empty project because if you create project from scratch, you will clearly understand the structure of project <br>
When you understand project's structure, you can use available blazor template <br>
I commented code in project, all you need to do is open and read it from this branch <br>
Some files you should read -> `Program.cs -> Pages/_Host.cshtml -> App.razor -> Shared/MainLayout.razor -> Shared/MyNav.razor`
And `dotnet run` to start up project

### How to create project from scratch ?

Make you have basic understand about .NET and type `dotnet --list-sdks` to make sure you have dotnet sdks

> [!NOTE]
> We are going to create project by `VS code` by command line, you can use IDE(if you're familar with command line) but create project by command line is a good practice that you should know


Steps: <br>
1. Select location that you will place your project 
2. Type `dotnet new sln`, it will create a solution file which has the same name as the folder that contains it
3. Enter `dotnet new web -n NameOfYourProject --use-program-main`, it will create project named NameOfYourProject, `--use-program-main` is a option to remove top-level statement, or you can use `dotnet new web`for short but you will use default project name and use top-level statement
4. Add you project to solution file,if you do that you can use `SOLUTION EXPLORER` which has features like IDE or you can skip, use `dotnet sln add *.csproj`, your *.csproj file denpends on how you name your project
5. Finally, add some files and code like my project or you can visit this [link](https://www.yogihosting.com/blazor-first-application/) to have more details
