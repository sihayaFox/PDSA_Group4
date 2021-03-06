﻿using Nibm.Pdsa.Group4.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibm.Pdsa.Group4.Service
{
    public class ShortestPath : IShortestPath
    {
        int V;
        string[] bran;
        public ShortestPath(int Vs, string[] branches)
        {
            V = Vs;
            bran = branches;
        }
        public StringBuilder dijkstra(int[][] graph, int src)
        {
            int[] dist = new int[V]; // The output array. dist[i] will hold 
                                     // the shortest distance from src to i 

            // sptSet[i] will true if vertex i is included in shortest 
            // path tree or shortest distance from src to i is finalized 
            bool[] sptSet = new bool[V];

            // Initialize all distances as INFINITE and stpSet[] as false 
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // Distance of source vertex from itself is always 0 
            dist[src] = 0;

            // Find shortest path for all vertices 
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum distance vertex from the set of vertices 
                // not yet processed. u is always equal to src in first 
                // iteration. 
                int u = minDistance(dist, sptSet);

                // Mark the picked vertex as processed 
                sptSet[u] = true;

                // Update dist value of the adjacent vertices of the 
                // picked vertex. 
                for (int v = 0; v < V; v++)

                    // Update dist[v] only if is not in sptSet, there is an 
                    // edge from u to v, and total weight of path from src to 
                    // v through u is smaller than current value of dist[v] 
                    if (!sptSet[v] && graph[u][v] != 0 &&
                            dist[u] != int.MaxValue &&
                            dist[u] + graph[u][v] < dist[v])
                        dist[v] = dist[u] + graph[u][v];
            }

            // print the constructed distance array 
            return printSolution(dist, V, bran);
        }

        public int minDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        public StringBuilder printSolution(int[] dist, int n, string[] branches)
        {
            StringBuilder output = new StringBuilder();
            Console.WriteLine("Distance from selected branch");
            for (int i = 0; i < V; i++)
            {
                output.Append(branches[i] + " Distance " + dist[i] + "\n");
            }


            return output;
        }
    }
}
