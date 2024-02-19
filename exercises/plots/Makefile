CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Erf.gnuplot.png : Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set tics out ;\
		set title "Error function" ;\
		plot \
			"$<" with lines notitle \
			,"erf.data.txt" using 1:2 with points pointtype 6 notitle \
			,"erf.data.txt" using (-($$1)):(-($$2)) with points pointtype 6 notitle ;\
	' | tee log.gpi | gnuplot

Out.txt: main.exe 
	mono $< > $@

sfuns.dll : sfuns.cs ; $(MKLIB)
main.exe : main.cs sfuns.dll ; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
