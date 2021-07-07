using System;
using System.Collections.Generic;
using System.Text;

namespace mef3d
{
    public static class mathTools
    {
        
        public static void squareZeroes(List<List<float>> M, int n)
        {
            List<float> row = new List<float>();

            for(int i=0;i<n;i++)
            {
                row.Add(0f);
            }

            for(int i = 0; i < n; i++)
            {
                M.Add(row);
            }
        }

        public static void zerosMatrix(List<List<float>> M, int n, int m)
        {
            List<float> row = new List<float>();

            for (int i = 0; i < m; i++)
            {
                row.Add(0f);
            }

            for (int i = 0; i < n; i++)
            {
                M.Add(row);
            }
        }

        public static void zeroesVector(List<float> v, int n)
        {
            for(int i=0; i < n; i++)
            {
                v.Add(0f);
            }
        }

        public static void copyMatrix(List<List<float>> A, List<List<float>> B)
        {
            List<List<float>> clone = new List<List<float>>(A);
            B = clone;
        }

        public static float calculateMember(int i, int j, int r, List<List<float>> A, List<List<float>> B)
        {
            float member = 0;
            for(int k=0; k<r; k++)
            {
                member += A[i][k] * B[k][j];
            }
            return member;
        }

        public static List<List<float>> productMatrixMatrix(List<List<float>> A, List<List<float>> B, int n, int r, int m)
        {
            List<List<float>> R = new List<List<float>>();

            zerosMatrix(R, n, m);
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    R[i][j] = calculateMember(i, j, r, A, B);
                }
            }

            return R;
        }

        public static void productMatrixVector(List<List<float>> A, List<float> v, List<float> R)
        {
            for(int f = 0; f < A.Count; f++)
            {
                float cell = 0f;
                for(int c=0; c<v.Count; c++)
                {
                    cell += A[f][c] * v[c];
                }
                R[f] += cell;
            }
        }

        public static void productRealMatrix(float real, List<List<float>> M, List<List<float>> R)
        {
            squareZeroes(R, M.Count);
            for(int i=0; i<M.Count; i++)
            {
                for(int j=0; j < M[0].Count; j++)
                {
                    R[i][j] = real * M[i][j];
                }
            }
        }

        public static void getMinor(List<List<float>> M, int i, int j)
        {
            M.RemoveAt(0 + i);
            for(int k=0; k < M.Count; k++)
            {
                M[k].RemoveAt(M[k].IndexOf(M[k][0]) + j);
            }
        }

        public static float determinant(List<List<float>> M)
        {
            if (M.Count == 1) return M[0][0];
            else
            {
                float det = 0f;
                for(int i=0; i < M[0].Count; i++)
                {
                    List<List<float>> minor = new List<List<float>>();
                    copyMatrix(M, minor);
                    getMinor(minor, 0, i);
                    det += Convert.ToSingle(Math.Pow(-1, i)) * M[0][i] * determinant(minor);
                }
                return det;
            }
        }

        public static void cofactors(List<List<float>> M, List<List<float>> cof)
        {
            squareZeroes(cof, M.Count);
            for(int i=0; i < M.Count; i++)
            {
                for(int j=0; j < M[0].Count; j++)
                {
                    List<List<float>> minor = new List<List<float>>();
                    copyMatrix(M, minor);
                    getMinor(minor, i, j);
                    cof[i][j] = Convert.ToSingle(Math.Pow(-1, i + j)) * determinant(minor);
                }
            }
        }

        public static void transpose(List<List<float>> M, List<List<float>> T)
        {
            zerosMatrix(T, M[0].Count, M.Count);
            for(int i=0; i<M.Count; i++)
            {
                for(int j=0; j < M[0].Count; j++)
                {
                    T[j][i] = M[i][j];
                }
            }
        }

        public static void inverseMatrix(List<List<float>> M, List<List<float>> Minv)
        {
            Console.WriteLine("Iniciando cálculo de inversa");
            List<List<float>> cof = new List<List<float>>();
            List<List<float>> adj = new List<List<float>>();
            Console.WriteLine("Calculo de determinante...\n");
            float det = determinant(M);
            if (det == 0) Environment.Exit(0);
            Console.WriteLine("Iniciando cálculo de cofactores... \n");
            cofactors(M, cof);
            Console.WriteLine("Cálculo de la adjunta...\n");
            transpose(cof, adj);
            Console.WriteLine("Cálculo de inversa...\n");
            productRealMatrix(1 / det, adj, Minv);
        }
    }
}
