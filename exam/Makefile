CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
COMMON_CLASSES_DIR := ../homework/common_classes
ODE_DIR := ../homework/5_ode_new
CSC = mcs
export MONO_PATH := $(ODE_DIR):$(COMMON_CLASSES_DIR)
RUN = mono

all: one_step_plot.png two_step_plot.png two_step_plot_extra.png

one_step_plot.png : output_one_step.txt
	@echo '\
	set terminal pngcairo enhanced font "arial,10" size 800,600 ;\
	set output "$@" ;\
	set xlabel "x" ;\
	set ylabel "y" ;\
	set title "One-Step Runge-Kutta Solution" ;\
	plot \
	"output_one_step.txt" using 1:2 with lines title "y[0]", \
	"output_one_step.txt" using 1:3 with lines title "y[1]" \
	' | gnuplot

two_step_plot.png : output_two_step.txt
	@echo '\
	set terminal pngcairo enhanced font "arial,10" size 800,600 ;\
	set output "$@" ;\
	set xlabel "x" ;\
	set ylabel "y" ;\
	set title "Two-Step Runge-Kutta Solution" ;\
	plot \
	"output_two_step.txt" using 1:2 with lines title "y[0]", \
	"output_two_step.txt" using 1:3 with lines title "y[1]" \
	' | gnuplot

two_step_plot_extra.png : output_two_step_extra.txt
	@echo '\
	set terminal pngcairo enhanced font "arial,10" size 800,600 ;\
	set output "$@" ;\
	set xlabel "x" ;\
	set ylabel "y" ;\
	set title "Two-Step Runge-Kutta Solution with extra evaluation" ;\
	plot \
	"output_two_step_extra.txt" using 1:2 with lines title "y[0]", \
	"output_two_step_extra.txt" using 1:3 with lines title "y[1]" \
	' | gnuplot

output_one_step.txt: main.exe
	$(RUN) $<

output_two_step.txt: main.exe
	$(RUN) $<

output_two_step_extra.txt: main.exe
	$(RUN) $<

main.exe: main.cs vector.dll TestPotentials.dll RKOneStep.dll RKTwoStep.dll RKTwoStepExtra.dll
	$(CSC) -reference:vector.dll -reference:TestPotentials.dll -reference:RKOneStep.dll -reference:RKTwoStep.dll -reference:RKTwoStepExtra.dll $<

TestPotentials.dll: $(COMMON_CLASSES_DIR)/vec.cs TestPotentials.cs
	$(CSC) -reference:vector.dll -target:library -out:$@ TestPotentials.cs

vector.dll: $(COMMON_CLASSES_DIR)/vec.cs
	$(CSC) -target:library -out:$@ $(COMMON_CLASSES_DIR)/vec.cs

RKOneStep.dll: $(COMMON_CLASSES_DIR)/vec.cs $(ODE_DIR)/RungeKutta.cs
	$(CSC) -reference:vector.dll -target:library -out:$@ $(ODE_DIR)/RungeKutta.cs

RKTwoStep.dll: $(COMMON_CLASSES_DIR)/vec.cs RKTwoStep.cs $(ODE_DIR)/RungeKutta.cs
	$(CSC) -reference:RKOneStep.dll -reference:vector.dll -target:library -out:$@ RKTwoStep.cs

RKTwoStepExtra.dll: $(COMMON_CLASSES_DIR)/vec.cs RKTwoStepExtra.cs $(ODE_DIR)/RungeKutta.cs
	$(CSC) -reference:RKOneStep.dll -reference:vector.dll -target:library -out:$@ RKTwoStepExtra.cs

clean:
	$(RM) *.dll *.exe *.txt *.png
