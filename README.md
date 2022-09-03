Task Chaining and Continuation 
To complete the task, you need to write a program that executes a chain of four tasks:

Task 1: creates an array of 10 random integers.
Task 2: multiplies the array by a randomly generated number.
Task 3: sorts the array by ascending.
Task 4: calculates the average value.

Apply separate methods to implement required actions and convert the methods to corresponding tasks. Don't forget to cover all methods with unit test.

All tasks should print the values to the console. Use TPL continuations in your implementation.


It will take you about 2 hours to complete the task.

Please be aware that the task status is mandatory.

To successfully complete the task, review the following chapters from the guide Chaining Tasks Using Continuation Tasks:

Create a Continuation for a Single Antecedent
Pass Data to a Continuation
Additionally, check the article on the Random class which might come in handy while creating an array for random integers.

How this task will be evaluated
We expect your solution to the task to meet the following criteria:

The tasks are built according to the description and execute the required functions.
The tasks are chained with the ContinueWith() method and the whole chain is awaited at once.
The program returns an average value of the antecedent array of integers.
You can get the maximum of 20 points (100%) for this task. To pass the task, you need to get 70%.