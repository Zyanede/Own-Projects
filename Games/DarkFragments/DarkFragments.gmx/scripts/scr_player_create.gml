image_speed=0;
//so everything can see the player
global.player = id;

//image blending
image_blend = c_orange;

//stuff for background following/parallax

badend = -1;

//invincibility frams
invincible = false;
inv_duration = room_speed*1.5;
inv_counter = 0;

//blob state. True means wearing blob
blob = false;
blobification = 0;
blob_counter = 0;
blob_grabbing = false;
blob_ungrabbing = false;
blob_morphing = true;
blobified = false;
move_enabled = true;
death_delay = room_speed*2;
death_counter = 0;

blob_warning = false;

button_hold = 0;

//static speeds
grav = 1;
jump = 20;
walk_speed = 6;
run_speed = 9;

vsp = 0;
hsp = 0;
grounded = 0;

hp = 3;

//df stands for dark fragment. True means they have that one.
df_1 = false;
df_2 = false;
df_3 = false;
df_4 = false;
df_5 = false;


//running sound play check
runningsnd = false;
