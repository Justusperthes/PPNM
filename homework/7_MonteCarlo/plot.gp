
            set terminal png
            set output 'plot.png'
            plot 'modified_data.txt' using 1:2 with lines
        