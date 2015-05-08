if(room == rm_main)
{
    keyA = keyboard_check_direct(ord('A'));
    keyD = keyboard_check_direct(ord('D'));
    key_shift = keyboard_check_direct(vk_shift);
    keySpace = keyboard_check_direct(vk_space);
    mouseRight = mouse_check_button_pressed(mb_right);
    key_e = keyboard_check_direct(ord('E'));
    
        
    //blobification
    if(blob)
        blobification+=1/(room_speed*15);
    else
        blobification-=1/(room_speed*15);
    if(blobification<0)
        blobification = 0;
    if(blobification>1)
        blobification = 1;
    
    if(blobification>.75&&!blob_warning)
    {
        audio_play_sound(snd_blobify_warn, 0, 0);
        blob_warning = true;
    }
    if(!audio_is_playing(snd_blobify_warn))
    {
        blob_warning = false;   
    }
        
    //Running sound
    //if(((hsp > 0) && grounded) && !runningsnd) {
    //    runningsnd = true;
    //    audio_play_sound(snd_player_run,0,0);
    //}
    //Stop running sound
    //if(((hsp == 0) || !grounded) && runningsnd) {
    //    runningsnd = false;
    //    sound_stop(snd_player_run);
    //}
        
    //Movement left/right
    if (keyA && move_enabled)
    {
    if(grounded)
    {
        if(key_shift)
        {
            hsp = -walk_speed;
            image_speed=.33;
        }
        else
        {
            hsp = -run_speed;
            image_speed=.60;
        }
        if(!blob)
            sprite_index = spr_player_new_run;
        else
            sprite_index = spr_player_new_blob_run;
            
        image_xscale = -1;
    }
    else
    {
        image_xscale = -1;
        if(hsp>-walk_speed/5)
            hsp = -walk_speed/5
    }
    }
    
    else if (keyD && move_enabled)
    {
    
        if(grounded)
        {
            if(key_shift)
            {
                hsp = walk_speed;
                image_speed=.33;
            }
            else
            {
                hsp = run_speed;
                image_speed=.60;
            }
            image_xscale = 1;
            if(!blob)
            sprite_index = spr_player_new_run;
        else
            sprite_index = spr_player_new_blob_run;
        }
        else
        {
            image_xscale = 1;
            if(hsp<walk_speed/5)
                hsp = walk_speed/5
        }
    }
    if(keyboard_check_pressed(ord("E"))&& move_enabled && grounded)
    {
        if(blob)
        {
            hsp = 0;
            blob = false;
            sprite_index = spr_player_new_blobgrab;
            image_index = image_number-1;
            image_speed = 0;
            blob_ungrabbing = true;
            move_enabled = false;
            audio_stop_music();
            audio_play_music(snd_music, 1);
           
        }
        else
        {
            if(place_meeting(x, y, obj_blob))
            {
                hsp = 0;
                grab_blob = instance_place(x, y, obj_blob)
                blob = true;
                sprite_index = spr_player_new_blobgrab;
                image_index = 0;
                image_speed = 0;
                with(grab_blob)
                {
                    instance_destroy();
                }
                blob_grabbing = true;
                move_enabled = false;
                
                audio_stop_music();
                audio_play_music(snd_music_blob, 1);
              
            }
        }
    } 
    
    if(blobification >= 1)
    {
        death_counter++;
        move_enabled= false;
        blob_morphing=true;
        hsp = 0;
        sprite_index = spr_player_new_death;
        image_speed=0.25;
        invincible=true;
        //show_message("image index: "+string(image_index)+" Image_number: "+string(image_number));
        if(image_index >= image_number-2)
        {
            image_index = image_number-2;
            blobified = true;
        }
        if(death_counter>room_speed)
        {
            hp = 0;
        }
        
        
    }
    
    
    
    if(blob_grabbing)
    {
        blob_counter++;
        if(blob_counter = 5)
        {
            image_index+=1;
            blob_counter = 0;
        }
        if(image_index == image_number-1)
        {
            blob_grabbing = false;
            move_enabled = true;
            image_speed = .25;
        }
    }
    
    if(blob_ungrabbing)
    {
        blob_counter++;
        if(blob_counter = 5)
        {
            image_index-=1;
            blob_counter = 0;
        }
        if(image_index == 2)
        {
            blob_ungrabbing = false;
            move_enabled = true;
            image_speed = .25;
            bloob = instance_create(x+(15*image_xscale), y-10, obj_blob);
            bloob.walk_counter = bloob.walk_delay/2;
            bloob.image_speed = 0;
            if(image_xscale<0)
            {
                bloob.left = true;
                bloob.image_xscale = -1;
            }
        }
    }
    
    
    //No input and both inputs
    if (((keyA && keyD) or (!keyA && !keyD)) and grounded and move_enabled)
    {
        hsp = 0; 
        image_speed=.25;
        if(!blob)
            sprite_index = spr_player_new;
        else
            sprite_index = spr_player_new_blob;
    }
    
    //Jump
    if (keySpace && move_enabled)
    {
        if (grounded) 
        {
            vsp =-jump;
            if(hsp>walk_speed)
                hsp=walk_speed;
            if(!blob)
            sprite_index = spr_player_new_run;
            else
            sprite_index = spr_player_new_blob_run;   
            image_index = 5;
            image_speed = 0;
        }
    }
    
    vsp += grav;
    
    //Vert Collision Ground
    if place_meeting(x,y+vsp,obj_ground)
    {
        while (!place_meeting(x,y+(sign(vsp)),obj_ground)) y += sign(vsp);
        if (sign(vsp) == 1) grounded = 1;
        if(!blob_grabbing && !blob_ungrabbing)
        {
            if(sprite_index != spr_player_new && sprite_index != spr_player_new_run && sprite_index != spr_player_new_blob && sprite_index != spr_player_new_blob_run)
            {
                if(blob)
                    sprite_index = spr_player_new_blob;
                else
                    sprite_index = spr_player_new;
            }
        }
        vsp = 0;
        
    }
    else
    {
        grounded = 0;
    }
    
    //Hor Collision ground
    if place_meeting(x+hsp,y,obj_ground)
    {
        while (!place_meeting(x+sign(hsp),y,obj_ground)) x += sign(hsp);
        hsp = 0;
    }
    
    //Water collision
    if(place_meeting(x, y, obj_water))
    {
        if(hp > 0)
            audio_play_sound(snd_splash,0,0);
        vsp = 2;
        hp = 0;
        grounded = 0;
    }
    
    //Try Win
    if(place_meeting(x, y, obj_goal))
    {
        if(df_1 && df_2 && df_3 && df_4 && df_5)
        {
            badend = false;
        }
        else
        {
            badend = true;
            show_message("You missed some fragments");
        }
    }
    
    //COLLISIONS WITH ENEMIES AND COLLECTIBLES BELOW THIS POINT//
    
    if(blob)
    {
        if(place_meeting(x, y, obj_df_1))
        {
            fragment = instance_place(x, y, obj_df_1);
            df_1 = true;
            with(fragment)
            {
                instance_destroy();
            }
        }
        
        if(place_meeting(x, y, obj_df_2))
        {
            fragment = instance_place(x, y, obj_df_2);
            df_2 = true;
            with(fragment)
            {
                instance_destroy();
            }
        }
        
        if(place_meeting(x, y, obj_df_3))
        {
            fragment = instance_place(x, y, obj_df_3);
            df_3 = true;
            with(fragment)
            {
                instance_destroy();
            }
        }
        
        if(place_meeting(x, y, obj_df_4))
        {
            fragment = instance_place(x, y, obj_df_4);
            df_4 = true;
            with(fragment)
            {
                instance_destroy();
            }
        }
        
        if(place_meeting(x, y, obj_df_5))
        {
            fragment = instance_place(x, y, obj_df_5);
            df_5 = true;
            with(fragment)
            {
                instance_destroy();
            }
        }
    }
    
    if(place_meeting(x, y, obj_enemy_blob) && !invincible)
    {
        invincible=true;
        inv_counter = inv_duration;
        
        if(grounded)
            x+=30*-sign(hsp)+1;
            
        vsp-=15;
        hp-=1;
        if(blob)
        {
            blob = false;
            bloob = instance_create(x, y-50, obj_blob);
            bloob.vsp=-20;
            bloob.hsp=10*sign(hsp);
            audio_stop_music();
            audio_play_music(snd_music, 1);
        }
        sprite_index = spr_player_new_hit;
    }
    
    //INVINCIBILITY STUFF//
    inv_counter--;
    if(inv_counter<=0)
    {
        inv_counter = 0;
        invincible = false;
        image_alpha = 1;
    }
    
    if(invincible)
    {
        image_alpha = .5;
    }
    
    //background manipulation
    
    background_x[0] = view_xview[0]/1.03;
    background_x[1] = view_xview[0]/1.07;
    
    
    x += hsp;
    y += vsp;
}

if(room = rm_title)
{
    sprite_index = spr_player_new_blob;
    image_speed = 0.20;
}
