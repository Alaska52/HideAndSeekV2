using UnityEngine;

// planned layers to have:
// ** presence layer (where was the seeker recently)
// ** FOV layer ( which cells are visible to seeker)
// ** openness layer (which cells are exposed and open)
// ** wall distance layer ?? (which cells are near cover or corners)
public class InfluenceMap : MonoBehaviour
{
    private Vector3 anchorLocation; //world location of map
    private float cellSize; // cell size in world units
    private int height, width;
    private float[,] influences; // i think i need more than 1?

    /* grid set up*/
    public void SetLayerDimensions(int width, int height)
    {
        //for (int i
    }

    public void SetPresenceLayer()
    {
        // affected by seeker's position, nearby cells become dangerous, further cells are less dangerous
    }

    public void SetVisibilityLayer()
    {
        // calculated from seeker's line of sight and direction vector

    }


    /* cell manipulation */

    public void SetCellValue()
    {

    }

    public void GetCellValue()
    {

    }

    public void AddValue()
    {
        
    }

    /* propogating */
    public void PropogateInfluence( int centerX, int centerY, // need to know where is the center of what we are propogating
                                    int radius, // radius we are extending out
                                    float magniture = 1.0f)
    {
        // this is the box that contains the circle we are propogating at
        int startX = centerX - (radius / 2);
        int startY = centerY - (radius / 2);
        int endX = centerX + (radius / 2);
        int endY = centerY + (radius / 2);
        

        // get the distance FROM AGENT to THE BOX calculated above
        // run it the response curve and drop it into the influence map
    }
}
