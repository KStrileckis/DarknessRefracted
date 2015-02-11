//SENSORS--Each section will include a description from the assignment

//Wall sensors
	// These project a ray relative to the heading of the robot, from the location of the robot outward to a maximum length (the maximum length is the sensor’s range).  Each wall sensor returns the distance before it intersects with the nearest wall, if one is within its range.  You should create at least three. 
  

//Adjacent agent sensors
	// Returns a list all agents within a fixed radius (the sensor’s range) of the agent.  Each entry in the list should identify the agent, and specify its distance from the subject and its relative heading, i.e. the angle from the subject’s heading to the detected agent (you do not need to take into account the detected agent’s heading).

//Pie-slice sensors
	// Divide the world around the subject into four pie slices in space.  Each pie slice is represented by two angles that are relative to the subject’s heading.  These angles are its boundaries.  When the subject rotates, the boundaries of each slice rotate with it.  Each pie slice can see ahead a maximum range.  For each pie slice, return an activation level proportional to the number of agents within the slice (i.e. bounded by its boundaries and its range).  For example, if there are no agents, its activation level is zero.  If there are three, its level is high.