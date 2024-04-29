CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
COMMON_CLASSES_DIR := /home/justusperthes/repos/PPNM/homework/common_classes
CSC = mcs
export MONO_PATH := $(COMMON_CLASSES_DIR)
RUN = mono

all: out.txt; cat $<

out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs $(COMMON_CLASSES_DIR)/TestNamespace.cs
	$(CSC) main.cs -r:$(COMMON_CLASSES_DIR)/TestNamespace.dll

$(COMMON_CLASSES_DIR)/TestNamespace.dll: $(COMMON_CLASSES_DIR)/TestNamespace.cs
	mcs $(COMMON_CLASSES_DIR)/TestNamespace.cs -target:library -out:$@


clean:
	$(RM) *.dll *.exe [Oo]ut*
