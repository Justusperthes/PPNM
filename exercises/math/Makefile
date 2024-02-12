# Makefile

# Compiler
CSC = mcs

# Compiler flags
CFLAGS = -warn:4

# Source files
SOURCES = math2.cs

# Executable name
EXECUTABLE = my_program.exe

# Output file
OUTPUT_FILE = output.txt

all: $(EXECUTABLE)

$(EXECUTABLE): $(SOURCES)
    $(CSC) $(CFLAGS) -out:$@ $^

run: $(EXECUTABLE)
    mono $(EXECUTABLE) > $(OUTPUT_FILE)

clean:
    rm -f $(EXECUTABLE) $(OUTPUT_FILE)
