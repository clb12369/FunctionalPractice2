/**
 * generics, funcs vs. actions vs. delegates, lambda expressions
 * static extension methods
 */

using System;
using System.Diagnostics;
//using System.Collections;
using System.Collections.Generic;

public static class Extensions {
    public static void print<T>(this IEnumerable<T> l){
        Console.WriteLine("<"+string.Join(",", l)+">");
    }
}

public class Program {

    // map and reduce provided
    public static List<O> map<T,O>(IEnumerable<T> arr, Func<T,O> fn){
        List<O> output = new List<O>();

        foreach(T t in arr){
            output.Add(fn(t));
        }

        return output;
    }

    public static O reduce<T, O>(IEnumerable<T> arr, Func<O, T, O> fn, O acc = default(O)){
        foreach(T t in arr){
            acc = fn(acc, t);
        }
        return acc;
    }

    //  Part I
    // ----------------------------
    // write your own forEach() using map() from above that takes an array and a function
    // ----------------------------
    public static void forEach<T>(IEnumerable<T> arr, Func<T, int> fn){
        // YOUR CODE HERE
        map<T, int>(arr, fn);
    }

    // PART II
    // ----------------------------
    // using reduce() from above, write your own filter()
    // that takes an array and a function
    // ----------------------------
    public static List<T> filter<T>(IEnumerable<T> coll, Func<T,bool> fn){
          // YOUR CODE HERE
          List<T> reduced = reduce<T, int>(reduced, coll, (v) => v % 2);
          return reduced;    
    }

    // PART III
    // ----------------------------
    // using reduce() from above, write your own sum()
    // that adds up all arguments to sum (note: variadic behavior)
    // ----------------------------
    public static int sum(params int[] nums){
         // YOUR CODE HERE
         return reduce<int, int>(nums, (acc, v) => acc + v);
    }

    public static void Main(){
        // examples
        map<int,int>(new List<int>(new []{1,2,3}), (a) => 1).print();
        map<bool,bool>(new List<bool>(new []{true,true,true}), (a) => !a).print();
        Console.WriteLine(reduce<int, int>(new int[]{1,2,3,4,5}, (acc,x) => acc+x));

        // tests
        // ---
        int total = 1;
        forEach<int>(new int[]{ 1, 2, 3, 4}, (a) => total *= a);
        Debug.Assert(total == 24);

       Debug.Assert(reduce<int, int>(new int[] { 1, 2, 3, 4 }, (a, v) => a*v) == 24);

        var squares = map(new int[] { 1, 2, 3, 4 }, (v) => v*v);
        Debug.Assert(squares[0] == 1);
        Debug.Assert(squares[1] == 4);
        Debug.Assert(squares[2] == 9);
        Debug.Assert(squares[3] == 16);

        var evens = filter(new int[]{1, 2, 3, 4}, (v) => v%2 == 0);
        Debug.Assert(evens[0] == 2);
        Debug.Assert(evens[1] == 4);

        Debug.Assert(sum(1, 2, 3) == 6);
        Debug.Assert(sum(1, 2, 3, 4) == 10);
        Debug.Assert(sum(1, 2, 3, 4, 5) == 15);
    }
}

