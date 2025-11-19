# FolderFusion 📂➡️📄

A powerful and flexible directory scanning tool that recursively processes files and folders, extracting text content based on customizable filters.

## ✨ Features

- **Dual Filter Modes**: Choose between "Consider" (whitelist) or "Ignore" (blacklist) filtering strategies
- **Customizable Patterns**: Define file extensions, folder names, and specific files to include or exclude
- **Text Extraction**: Automatically extracts and consolidates text content from multiple files
- **Interactive Menu**: User-friendly console interface for easy configuration
- **JSON Configuration**: Simple settings management via JSON files
- **Cross-Platform**: Built with .NET for Windows compatibility

## 🚀 Quick Start

1. **Run the application**:
   ```bash
   dotnet run
   ```

2. **Configure your settings** through the interactive menu
3. **Choose your filtering strategy** in Settings
4. **Define patterns** in Consider.txt or Ignore.txt
5. **Start scanning** and let FolderFusion do the work!

## ⚙️ Configuration

### Settings (settings.json)
```json
{
  "GetAllDirsAndFiles": "Consider",
  "IsWriteDirecoryName": "true"
}
```

- **GetAllDirsAndFiles**: Filter mode - "Consider" (whitelist) or "Ignore" (blacklist)
- **IsWriteDirecoryName**: "true" to include full paths, "false" for relative paths

### Filter Files

**Consider.txt** (whitelist mode):
```
.cs
.txt
.md
.json
ImportantFolder
```

**Ignore.txt** (blacklist mode):
```
.git
bin
obj
*.tmp
.log
```

## 🎯 Usage

### Main Menu Options:
- **1. Start work** - Begin directory scanning with current settings
- **2. Open Settings file** - Edit configuration directly
- **3. Open Consider list** - Manage whitelist patterns
- **4. Open Ignore list** - Manage blacklist patterns  
- **5. Open Result file** - View extracted content
- **6. Change Settings** - Interactive settings editor
- **7. Exit** - Close the application

### Pattern Syntax:
- **File Extensions**: `.cs`, `.txt`, `.md`
- **Folder Names**: `bin`, `obj`, `ImportantFolder`
- **File Names**: `README.md`, `config.json`

## 📁 Output

All extracted text is saved to `Result.txt` with:
- File paths (configurable)
- File contents
- Clear separation between files

## 🛠️ Technical Details

- **Platform**: .NET 9.0
- **Dependencies**: System.Text.Json for configuration
- **File Processing**: Recursive directory traversal
- **Error Handling**: Comprehensive exception management

## 💡 Use Cases

- **Code Documentation**: Extract and analyze source code comments
- **Content Migration**: Consolidate text from multiple files
- **Project Analysis**: Scan and process specific file types
- **Data Extraction**: Gather text content from structured directories

## 🔧 Building

```bash
dotnet build
dotnet run
```

---

**FolderFusion** - Your smart directory scanner and text consolidator!