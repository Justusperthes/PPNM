
            set terminal png
            set output 'plot.png'
            set xlabel 't (days)'
            set ylabel 'activity
            plot 'data.txt' with lines title 'Exponential Fit'
        