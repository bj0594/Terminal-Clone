# Terminal Clone

A group project in C# where we recreated several common CLI commands used in terminals such as Git Bash and Linux shells.

The program runs as an interactive CLI. After starting it, the user can enter commands directly in the terminal.

## Run the program

```bash
dotnet run
```

Example:

```text
PS C:\Terminal-Clone> ls
PS C:\Terminal-Clone> head TestFiles/test.txt
PS C:\Terminal-Clone> echo Hello world
```

Type `exit` to close the program.

---

## Commands

### LineManager

Handles commands that read and analyze file content.

#### `head`

Shows the first 10 lines of a file.

```text
head <file>
```

You can also choose the number of lines with `-n`:

```text
head -n 5 <file>
```

#### `tail`

Shows the last 10 lines of a file.

```text
tail <file>
```

You can also choose the number of lines with `-n`:

```text
tail -n 5 <file>
```

#### `wc`

Displays information about a file:

* Number of lines
* Number of words
* Number of characters
* Number of bytes

```text
wc <file>
```

---

### FileManager

Handles file creation, copying, moving, renaming, and deleting.

#### `touch`

Creates a new empty file.

```text
touch <file>
```

#### `cp`

Copies a file to a new name or location.

```text
cp <source> <destination>
```

#### `mv`

Moves a file or renames it.

```text
mv <source> <destination>
```

#### `rm`

Deletes a file.

```text
rm <file>
```

---

### InfoManager

Handles commands that display information in the terminal.

#### `ls`

Lists files and folders in the current working directory.

```text
ls
```

#### `cat`

Displays the content of a file.

```text
cat <file>
```

#### `echo`

Prints text to the terminal.

```text
echo Hello world
```

---

## Project Structure

The project is divided into separate areas so the code is easier to organize and reuse.

```text
Program.cs
│
├── LineManager
│   ├── head
│   ├── tail
│   └── wc
│
├── FileManager
│   ├── touch
│   ├── cp
│   ├── mv
│   └── rm
│
└── InfoManager
    ├── ls
    ├── cat
    └── echo
```

`Program.cs` handles user input and decides which command should run. The command logic is kept in separate classes.

---

## Short Reflection

Several of the commands use similar concepts, especially file handling through `System.IO`.

`head`, `tail`, and `wc` all read data from files, while `touch`, `cp`, `mv`, and `rm` modify files in the file system.

By separating the functionality into different classes, we avoid placing all logic inside `Program.cs` and make parts of the code easier to reuse.

CLI tools are still widely used because they are fast, lightweight, easy to automate, and work well with scripts, Git, and other developer tools.

---

## Possible Improvements

Some features we could add later:

* Support for file and folder names containing spaces
* More command arguments and flags
* Additional CLI commands
* More detailed error handling
* More options for `wc`, such as counting only lines or words
* Better support for navigating between directories
