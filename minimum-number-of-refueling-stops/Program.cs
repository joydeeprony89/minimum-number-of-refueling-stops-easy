namespace minimum_number_of_refueling_stops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Solution
    {
        // https://www.youtube.com/watch?v=sKjKLN5JswQ
        public int MinRefuelStops(int target, int startFuel, int[][] stations)
        {
            var pq = new PriorityQueue<int, int>();
            int max_reach = startFuel;
            int n = stations.Length;
            int ans = 0;
            int i = 0;
            while (max_reach < target)
            {
                while (i < n && max_reach >= stations[i][0])
                {
                    var fuel = stations[i][1] * -1;
                    pq.Enqueue(fuel, fuel);
                    i++;
                }
                if (max_reach >= target) return ans;
                if (pq.Count == 0) return -1;
                var fuel_ = pq.Dequeue();
                fuel_ *= -1;
                max_reach += fuel_;
                ans++;
            }
            return ans;
        }
    }
}
