vsp+=grav

if place_meeting(x,y+vsp,obj_ground)
{
    while (!place_meeting(x,y+(sign(vsp)),obj_ground)) y += sign(vsp);
    if (sign(vsp) == 1) grounded = 1;
    vsp = 0;
    
}

if place_meeting(x+hsp,y,obj_ground)
{
    while (!place_meeting(x+sign(hsp),y,obj_ground)) x += sign(hsp);
    hsp = 0;
}

if(left)
{

    if(idle_counter == 0 && walk_counter==0)
    {
        hsp = -movement_speed;
        image_xscale = -1;
        image_speed = .28;
        walk_counter = walk_delay;
        if(x>view_xview[0] && x<=view_xview[0]+view_hport[0])
            audio_play_sound(snd_blob_move, 0, 0);
        left = false;
    }

}
else
{
    if(idle_counter == 0 && walk_counter==0)
    {
        hsp = movement_speed;
        image_xscale = 1;
        image_speed = .28;
        walk_counter = walk_delay;
        if(x>view_xview[0] && x<=view_xview[0]+view_hport[0])
            audio_play_sound(snd_blob_move, 0, 0);
        left = true;
    }
}

walk_counter--;
idle_counter--;

if(walk_counter == 0)
{
    hsp = 0;
    image_speed = 0;
    image_index = 0;
    idle_counter = idle_delay;
}

if(walk_counter<0)
    walk_counter=0;
if(idle_counter<0)
    idle_counter=0;
    
if(place_meeting(x, y, obj_water))
{
    vsp = 2;
    hsp=.1*sign(hsp);
}
    
    
x += hsp;
y += vsp;
