# Readme for Sprint 3
## Team 5 - The Mario Party

This project is an implementation of Super Mario Bros. World 1-1.
In our current implementation, we have a lot of similar gameplay,
but the following deviations from the original game (as of this
sprint):
- Mario can walk backwards to the beginning of the level
- The camera viewport follows Mario throughout the game, and Mario
  is centered in the frame.
While our implementation is in progress, we have a sample level
available that demonstrates how interactions with objects,
collisions, and enemy killing can occur.

At this time, we have yet to implement a way to kill enemies using
the Fire Flower powerup, but we will accomplish that in a future
sprint.

## Known Bugs
- There is an issue where the Koopa Troopas will ignore bricks and
  walk past them.
- If Mario jumps up against the left or right edge of a block, he
  may skyrocket into the air (we may consider this for a wall jump
  in the future).
- The lucky block does not give any power ups at this time.
- Mario may be sucked into staircase blocks.
- Mario may not switch direction when he is squatting and moving.

## Code Reviews
Our code reviews for this sprint are contained within the pull
requests. Each team member has completed at least one code
review, some for the same pull
request. 

If there are any issues with finding the pull requests where these
happened, a list of them can be found below.

### Pull Requests with Completed Code Reviews
- PR #167 (Will)
- PR #146 (Srujan)
- PR #144 (Micah)
- PR #162 (Jack)
- PR #145 (Matthew)
- PR #154 (Jacob)

### Keyboard Controls

| **Key** | **Action** |
| --- | --- |
| Q, ESC | Quit Game |
| R, 2 | Reset Level |
| W, [Up-Arrow] | Mario Jump |
| A, [Left-Arrow] | Mario Move Left |
| S, [Down-Arrow] | Mario Move Right |
| D, [Right-Arrow] | Mario Squat |
| E | Hurt Mario |
| F | Power Up Mario |
| 1, Z, N | Launch Fire Ball |

