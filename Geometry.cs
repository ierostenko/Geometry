using UnityEngine;

namespace Geometry
{
    public static class GeometryCalculations
    {
        // 2D space
        public static bool IsLinesIntersect(Line line1, Line line2, out Vector2 intersectPoint)
        {
            intersectPoint = Vector2.zero;

            // Denominator for ua and ub are the same, so store this calculation
            float d = (line2.p2.y - line2.p1.y) * (line1.p2.x - line1.p1.x) - (line2.p2.x - line2.p1.x) * (line1.p2.y - line1.p1.y);

            //n_a and n_b are calculated as seperate values for readability (numerators)
            float n_a = (line2.p2.x - line2.p1.x) * (line1.p1.y - line2.p1.y) - (line2.p2.y - line2.p1.y) * (line1.p1.x - line2.p1.x);
            
            float n_b = (line1.p2.x - line1.p1.x) * (line1.p1.y - line2.p1.y) - (line1.p2.y - line1.p1.y) * (line1.p1.x - line2.p1.x);

            // Make sure there is not a division by zero - this also indicates that
            // the lines are parallel.  
            // If n_a and n_b were both equal to zero the lines would be on top of each 
            // other (coincidental).  This check is not done because it is not 
            // necessary for this implementation (the parallel check accounts for this).
            if (d == 0)
                return false;

            // Calculate the intermediate fractional point that the lines potentially intersect.
            float ua = n_a / d;
            float ub = n_b / d;

            // The fractional point will be between 0 and 1 inclusive if the lines
            // intersect.  If the fractional calculation is larger than 1 or smaller
            // than 0 the lines would need to be longer to intersect.
            if (ua >= 0f && ua <= 1f && ub >= 0f && ub <= 1f)
            {
                intersectPoint = new Vector2( line1.p1.x + (ua * (line1.p2.x - line1.p1.x)),
                                              line1.p1.y + (ua * (line1.p2.y - line1.p1.y)));

                return true;
            }
            return false;
        }
    }


    public struct Line
    {
        public Vector2 p1;
        public Vector2 p2;

        public Line(Vector2 p1, Vector2 p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
    }
}



