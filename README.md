# Mesh Statistics

A Unity Editor tool that analyzes all meshes in your scene and lists them by polygon count, from highest to lowest. This helps you identify meshes that may require optimization to improve performance.

## Features

- **Analyze Meshes**: Quickly scan all meshes in the current scene.
- **Include Skinned Meshes**: Option to include skinned meshes in the analysis.
- **Sort by Poly Count**: Lists meshes from highest to lowest polygon count.
- **Select Meshes**: Easily select a mesh in the scene directly from the list.

## Installation

1. **Download the Script**

   Save the `MeshStatistics.cs` script into your project's `Assets/Editor` folder. If the `Editor` folder doesn't exist, create it inside the `Assets` folder.

2. **Unity Compilation**

   Open your Unity project. Unity will automatically compile the new script.

## How to Use

1. **Open Mesh Statistics**

   In the Unity menu bar, go to:

   `Tools -> Mesh Statistics`

2. **Include Skinned Meshes (Optional)**

   - In the Mesh Statistics window, you'll see a checkbox labeled **Include Skinned Meshes**.
   - Check this box if you want to include skinned meshes in the analysis.

3. **Analyze Meshes**

   Click the **Analyze Meshes** button.

4. **View Results**

   - A list of all meshes (and skinned meshes if included) in the scene will be displayed, ordered by polygon count from highest to lowest.
   - Each entry shows the mesh name and its polygon count.

5. **Select a Mesh**

   - Click the **Select** button next to a mesh to highlight it in the Hierarchy and Inspector.
   - This allows you to quickly locate and inspect high-poly meshes.

## Benefits

- **Performance Optimization**: Identify and optimize high-poly meshes to improve game performance.
- **Workflow Efficiency**: Save time by quickly locating meshes that may need attention.

## Requirements

- **Unity Editor**: Version 2019.1 or higher is recommended for best compatibility.

## Contributing

Contributions are welcome! If you have suggestions or improvements, feel free to submit a pull request or open an issue.

## License

This project is licensed under the [MIT License](LICENSE).
