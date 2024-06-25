CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
COMMON_CLASSES_DIR := ../common_classes
CSC = mcs
export MONO_PATH := $(COMMON_CLASSES_DIR)
RUN = mono

all: out.txt

out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs vector.dll RungeKutta.dll
	$(CSC) -reference:vector.dll -reference:RungeKutta.dll $<

vector.dll: $(COMMON_CLASSES_DIR)/vec.cs
	$(CSC) -target:library -out:$@ $(COMMON_CLASSES_DIR)/vec.cs

RungeKutta.dll: $(COMMON_CLASSES_DIR)/vec.cs RungeKutta.cs
	$(CSC) -reference:vector.dll -target:library -out:$@ RungeKutta.cs

clean:
	$(RM) *.dll *.exe *.txt