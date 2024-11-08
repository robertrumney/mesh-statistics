# Mesh Statistics

A Unity Editor tool that analyzes all meshes in your scene or entire project and lists them by polygon count, from highest to lowest. This helps you identify meshes that may require optimization to improve performance.

## Features

- **Analyze Meshes**: Quickly scan all meshes either in the current scene or across the entire project.
- **Include Skinned Meshes**: Option to include skinned meshes in the analysis.
- **Scope Selection**: Choose to analyze meshes within the current scene or the entire project.
- **Sort by Poly Count**: Lists meshes from highest to lowest polygon count.
- **Select or Ping Meshes**: Easily select a mesh in the scene or ping it in the project browser directly from the list.

## Installation

1. Copy the `TextureUsageWindow.cs` script to your Unity project inside an `Editor` folder.
2. In Unity, navigate to `Window > Texture Usage` to open the Texture Usage Window.

## How to Use

1. **Open Mesh Statistics**

   In the Unity menu bar, go to:

   `Tools -> Mesh Statistics`

2. **Include Skinned Meshes (Optional)**

   - In the Mesh Statistics window, you'll see a checkbox labeled **Include Skinned Meshes**.
   - Check this box if you want to include skinned meshes in the analysis.

3. **Select Analysis Scope**

   - Choose whether to analyze meshes in the current scene or across the entire project.

4. **Analyze Meshes**

   Click the **Analyze Meshes** button.

5. **View Results**

   - A list of all meshes (and skinned meshes if included) in the scene or project will be displayed, ordered by polygon count from highest to lowest.
   - Each entry shows the mesh name and its polygon count.

6. **Select or Ping a Mesh**

   - For meshes in the scene: Click the **Select** button next to a mesh to highlight it in the Hierarchy and Inspector.
   - For meshes in the project: Click the **Ping in Project** button to locate the mesh asset in the Project browser.
   - This allows you to quickly locate and inspect high-poly meshes.

## Benefits

- **Performance Optimization**: Identify and optimize high-poly meshes to improve game performance.
- **Workflow Efficiency**: Save time by quickly locating and handling meshes that may need attention.

## Requirements

- **Unity Editor**: Version 2019.1 or higher is recommended for best compatibility.

## Contributing

Contributions are welcome! If you have suggestions or improvements, feel free to submit a pull request or open an issue.

## License

This project is licensed under the [MIT License](LICENSE).
