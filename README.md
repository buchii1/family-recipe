# Family Recipes App

Welcome to the Family Recipes App! This application is designed to help users share and discover family recipes, connect with other food enthusiasts, and manage their favorite dishes. 

## Table of Contents
- [Family Recipes App](#family-recipes-app)
  - [Table of Contents](#table-of-contents)
  - [About the Project](#about-the-project)
  - [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
  - [Usage](#usage)
  - [Contributing](#contributing)
    - [Contributor's Guide](#contributors-guide)
  - [License](#license)
  - [Contact](#contact)

## About the Project

The Family Recipes App is a platform where users can create, share, and explore a variety of recipes. It includes features such as user registration, profile management, recipe creation, search functionality, and more. The app is built using Blazor and ASP.NET Core, providing a seamless and interactive user experience.

## Getting Started

To get a local copy up and running, follow these steps.

### Prerequisites

Before you begin, ensure you have the following installed:

- .NET 6 SDK
- Visual Studio 2022 or Visual Studio Code
- SQL Server or sqllite

### Installation

1. **Clone the repository:**

   ```sh
   git clone https://github.com/buchii1/family-recipe.git
   cd FamilyRecipesApp
   ```

2. **Set up the database:**

   - Open `appsettings.json` in the `Server` directory and configure the `ConnectionStrings` to your local SQL Server instance.

3. **Build the project:**

   ```sh
   dotnet build
   ```

4. **Apply migrations and update the database:**

   ```sh
   dotnet ef database update --project Server
   ```

5. **Run the application:**

   ```sh
   dotnet run --project Server
   ```

   The application will be available at `https://localhost:5001`.

## Usage

1. **Open your browser and navigate to `https://localhost:5001`.**
2. **Register a new account or log in with existing credentials.**
3. **Update your profile with your first and last name, biography, email address, and profile picture.**
4. **Explore, add, edit, and delete recipes.**
5. **Use the search functionality to find specific recipes.**

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

### Contributor's Guide

1. **Fork the Project:**

   Click the "Fork" button at the top right of the repository page.

2. **Create your Feature Branch:**

   ```sh
   git checkout -b feature/YourFeature
   ```

3. **Commit your Changes:**

   ```sh
   git commit -m 'Add some feature'
   ```

4. **Push to the Branch:**

   ```sh
   git push origin feature/YourFeature
   ```

5. **Open a Pull Request:**

   Go to the repository on GitHub and click the "Compare & pull request" button.

## License

Distributed under the MIT License. See `LICENSE` for more information.

## Contact

- **Live Project Link:** [Family Recipes App](https://familyrecipesapp.azurewebsites.net)
- **Support Email:** [okonkwogodspower@yahoo.com](mailto:okonkwogodspower@yahoo.com)