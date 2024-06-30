
# 27
# ODE: a two-step method
# Implement a two-step stepper for solving ODE (as in the book). Use your own adaptive stepsize driver.

My initial ODE integrator was not working properly from Homework 5, so I have had to remake this to work 
(which I have called "5_ode_new).
The two-step integrator inherits from the RungeKutta solver from 5_ode_new which implements a one-step
method. It thus extends my RungeKutta solver to use a two-step method, and also to use a two-step method 
with an extra step.