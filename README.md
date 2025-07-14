# **Arabic SRT Fixer**

A simple Windows Forms application that processes SRT subtitle files and ensures proper display of Arabic text. The tool adds the Unicode Right-to-Left Embedding (RLE) character at the start of each Arabic line, fixing common punctuation and bidirectional formatting issues.

<img width="702" height="192" alt="image" src="https://github.com/user-attachments/assets/c67a379e-8751-4351-b889-fb37be913803" />

## Features

- Automatically detects Arabic lines in an SRT file

- Inserts the RLE Unicode character (`\u202B`) at the beginning of each detected line

- Preserves timestamps and non-Arabic content untouched

- Provides a clean, one-click interface for quick processing

- Outputs a new SRT file

## Installation

1. Clone or download this repository

2. Open the solution file (`ArabicSrtFixer.sln`) in Visual Studio

3. Build the solution in Release mode

4. The compiled executable will be located in `bin/Release`

OR

1. Download the latest executable file

## Usage

1. Launch `ArabicSrtFixer.exe`

2. Click **Open** and select your `.srt` file or drag and drop it onto the input field

3. Specify the output path if needed

4. Click **Process**

The application will process the file and display a confirmation once complete. You can then load the fixed subtitle in your media player.

## Building from Source

1. Ensure you have Visual Studio with the .NET desktop development workload

2. Open `ArabicSrtFixer.sln`

3. Build the project

## Contributing

Contributions are welcome. To contribute:

1. Fork the repository

2. Create a feature branch (`git checkout -b feature/YourFeature`)

3. Commit your changes (`git commit -m "Add YourFeature"`)

4. Push to the branch (`git push origin feature/YourFeature`)

5. Open a pull request

## License

This project is licensed under the **GNU General Public License v3.0**. See the LICENSE file for details.
