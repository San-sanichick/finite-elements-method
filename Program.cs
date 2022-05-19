static double Foo(double x, double y)
{
    return 2 * Math.Sin(x) * Math.Cos(y);
}

int N = 100;
double eps = Math.Pow(10, -4);
double a = 0, b = Math.PI;

double h = (b - a) / (double)N;

// По умолчанию заполнено нулями
double[,] u = new double[N, N];

for (int i = 0; i < N; i++)
{
    u[0, i]     = -Math.Sin(i * h);
    u[N - 1, i] =  Math.Sin(i * h);
}

double iterations = 0.2 * (N * N) * Math.Log(1 / eps);

double[,] uk = u;
double[,] uk1 = new double[N, N];

for (int k = 0; k < iterations; k++)
{
    for (int m = 1; m < N - 1; m++)
    {
        for (int n = 1; n < N - 1; n++)
        {
            uk1[m, n] = (1.0 / 4.0) * 
                (uk[m + 1, n] + uk[m - 1, n] + 
                 uk[m, n + 1] + uk[m, n - 1] + 
                (h * h * Foo(m * h, n * h)));

            uk = uk1;
        }
    }
}

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        Console.WriteLine($"u[{i}, {j}] = {uk[i, j]}");
    }
}

Console.WriteLine($"Result: u[{N / 2}, {N / 2}] {uk[N / 2, N / 2]}");