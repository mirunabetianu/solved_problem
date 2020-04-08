## Split array problem
In a given integer array A, we must move every element of A to either list B or list C. (B and C initially start empty.)


Return true if and only if after such a move, it is possible that the average value of B is equal to the average value of C, and B and C are both non-empty.


Sample input: [1,2,3,4,5,6,7,8]


Sample output: True


Explanation: We can split the array into [1,4,5,8] and [2,3,6,7], and both of them have the average of 4.5.


Note:


The length of A will be in the range [1, 30]. A[i] will be in the range of [0, 10000].


## Understanding the problem

Let’s start with an example. If the input array is _A = {1,2,3,4,5,6,7,8}_, by splitting randomly, we would have _B = {1,2,3,4,5}_ and _C = {6,7,8}_.


Notation:
*	_sum(A) = sum_
*	_size(A) = n_


We know that _sum = sum(B) + sum(C)_ and that _n = size(B) + size(C)_.

**But**  we have the following restriction: _average(B) = average(C)_. More precisely, _sum(B)/size(B) = sum(C)/size(C)_.


If we rewrite the first part in terms of A, we would have the following equation:
_sum(B)/size(B) = (sum – sum(B))/ (n – size(B))_. After multiplying the fractions equality diagonally and again applying some basic math, the final equality will be 
_sum(B) = size(B) * sum / n_.


This final form helps checking efficiently if such splitting is possible for the input array. Also, it needs to be verified by each possible size of _B_. 


The size of _B_ varies between _1_ and _n/2 + 1_. The reason of this variation is that the length of one partition needs to be less than _n/2._


This part of the problem, about making partitions, resembles one of the most known problems in dynamic programming: **sum subset problem**. 

So, for each number of the array we need to compute the possible sums of each partition of variable length and to store it in a table.

The last step is to check if one of the partitions with the length which verifies the final equality has the value of the its sum in the computed table.
