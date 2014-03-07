//to make using player less verbose
player = global.player;
if(!global.text_up)
{
    //Make sure to draw base sprite
    draw_self();
    //Draw hearts, taking into account player getting hit, etc.
    if(player.hp==3)
        draw_sprite( heart, 0, heart1_posx, heart1_posy );
    if(player.hp>=2)
        draw_sprite( heart, 0, heart2_posx, heart2_posy ); 
    if(player.hp>=1)
        draw_sprite( heart, 0, heart3_posx, heart3_posy );
        
    //Draw headslot, with human head at first
    //Then blob head when need be.
    draw_sprite( headslot, 0, headslot_posx, headslot_posy );
    if(player.blob)
    {
        draw_sprite(spr_blobbed_head, 0, headslot_posx, headslot_posy);
    }
    else
    {
        draw_sprite(spr_blobless_head, 0, headslot_posx, headslot_posy);
    }
    //Draw fragments the player has so far collected
    
    if(player.df_1 == true)
        draw_sprite( darkfragment, 0, darkfragment1_posx, darkfragment1_posy );
    if(player.df_2 == true)
        draw_sprite( darkfragment, 0, darkfragment2_posx, darkfragment2_posy );
    if(player.df_3 == true)
        draw_sprite( darkfragment, 0, darkfragment3_posx, darkfragment3_posy );
    if(player.df_4 == true)
        draw_sprite( darkfragment, 0, darkfragment4_posx, darkfragment4_posy );
    if(player.df_5 == true)
        draw_sprite( darkfragment, 0, darkfragment5_posx, darkfragment5_posy );
        
    //Draw background for goobar, and then draw the bar's current fill
    draw_sprite( goobar, 0, goobar_posx, goobar_posy );
    draw_sprite_ext(spr_blobification, 0, goobar_posx, goobar_posy, player.blobification, 1, 0, c_white, 1);
}

