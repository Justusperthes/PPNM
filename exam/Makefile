CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
COMMON_CLASSES_DIR := ../homework/common_classes
ODE_DIR := ../homework/5_ode_new
CSC = mcs
export MONO_PATH := $(ODE_DIR):$(COMMON_CLASSES_DIR)
RUN = mono

all: out.txt

out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs vector.dll RKOneStep.dll RKTwoStep.dll
	$(CSC) -reference:vector.dll -reference:RKOneStep.dll -reference:RKTwoStep.dll $<

vector.dll: $(COMMON_CLASSES_DIR)/vec.cs
	$(CSC) -target:library -out:$@ $(COMMON_CLASSES_DIR)/vec.cs

RKOneStep.dll: $(COMMON_CLASSES_DIR)/vec.cs $(ODE_DIR)/RungeKutta.cs
	$(CSC) -reference:vector.dll -target:library -out:$@ $(ODE_DIR)/RungeKutta.cs

RKTwoStep.dll: $(COMMON_CLASSES_DIR)/vec.cs RKTwoStep.cs $(ODE_DIR)/RungeKutta.cs
	$(CSC) -reference:RKOneStep.dll -reference:vector.dll -target:library -out:$@ RKTwoStep.cs

clean:
	$(RM) *.dll *.exe *.txt
