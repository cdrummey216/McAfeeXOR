# John McAfee - 05/26/2021 11:06AM

In my years as a programmer I observed numerous anomalies that may have practical applications. Since I'm getting no younger I thought I'd begin passing them on. 

The first, involving an anomaly with boolean algebra.

Boolean algebra is one of the foundations of computer science. There is an unusual property of the boolean XOR operation that I doubt many, or anyone at all, has considered:

If you take any three sets of characters of any equal length - let's label them A,B, and C - and then:

          XOR A to B
          Then XOR the result of B to C
          Then similarly XOR C to A

And then perform four iterations of the above. And finally:

          XOR A to B
          And then XOR B to C

It will result in the original contents of A moved to C, C moved to B, and B moved to A.

Of interest here is that the three results of the third iteration, though deterministic as a whole, are entirely random within each of the three independent data segments. Thus if any one of the three segments is missing or withheld, it is impossible, from the remaining two to extract even the tiniest fragment of the three original contents.

The simplicity of this process is astonishing. A person of average intelligence could decode a message, using pencil and paper, providing they possessed all three interim segments. 

I'm describing this tidbit in the hopes that my observations might be of some use to those engaged in the research of cryptography.
