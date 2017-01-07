using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    /**
  * Definition for an interval.
  * public class Interval {
  *     public int start;
  *     public int end;
  *     public Interval() { start = 0; end = 0; }
  *     public Interval(int s, int e) { start = s; end = e; }
  * }
  */



    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class IntervalMerge
    {
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            IList<Interval> res = new List<Interval>();
            if (intervals == null || intervals.Count == 0) return res;
            //Array.Sort(intervals,new CustomComparer<Interval>());

            var input = (List<Interval>)intervals;
            input.Sort(new CustomComparer());

            res.Add(input[0]);
            for (int i = 1; i < intervals.Count; i++)
            {
                Interval last = res[res.Count - 1];
                //Check the two consecutive intervals
                if (intervals[i].start > last.end)
                {
                    //No need to merge
                    res.Add(intervals[i]);

                }

                else
                {

                    if (last.end >= intervals[i].start)
                    {
                        res.RemoveAt(res.Count - 1);
                        int new_end = Math.Max(last.end, intervals[i].end);
                        Interval interval = new Interval(last.start, new_end);
                        res.Add(interval);
                    }

                }
            }

            return res;

        }

        public IList<Interval> InsertAndMerge(IList<Interval> intervals, Interval newInterval)
        {
            
            if(intervals==null||intervals.Count==0)
            {
                IList<Interval> res = new List<Interval>();
                res.Add(newInterval);
                return res;
            }
            if(newInterval==null)
            {
                return intervals;
            }
            if(newInterval.end<intervals[0].start)
            {
                intervals.Insert(0, newInterval);
                return intervals;
            }
            else if (newInterval.start > intervals[intervals.Count - 1].end)
            {
                intervals.Add(newInterval);
                return intervals;
            }
            else
            {
                int i = 0;
                while(i<intervals.Count)
                {
                    if(intervals[i].start<=newInterval.start)
                    {
                        break;
                    }
                    i++;
                }
                intervals.Insert(i + 1, newInterval);
                Merge(intervals, i);
                return intervals;
            }
        }

        private void Merge(IList<Interval> intervals, int i)
        {
            Interval prev = intervals[i];

            i = i + 1;
            while(i<intervals.Count)
            {
                Interval current = intervals[i];
                //Interval next = intervals[i + 1];
                //current = newInterval;
                if (prev.end < current.start)
                {
                    
                }
                else
                {
                   
                    Interval inter = new Interval(prev.start, Math.Max(current.end, prev.end));
                    intervals.RemoveAt(i-1);
                    intervals.RemoveAt(i-1);
                    intervals.Insert(i-1,inter);
                    
                }
                prev = intervals[i];
                i++;
            } 
        }
    }

    public class CustomComparer : IComparer<Interval>
    {

        public int Compare(Interval a, Interval b)
        {
            if (a.start != b.start)
            {
                return a.start - b.start;
            }
            else
            {
                return a.end - b.end;
            }

        }

    }
}
