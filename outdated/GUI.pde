//Model - View - Controller

abstract class GUI{
  ControlP5 cp5;
  
  GUI(PApplet thePApplet){
    this.cp5 = new ControlP5(thePApplet);
    cp5.hide();
  }
  
  public void display(GUI gui){
    this.cp5.hide();
    screen = gui;
    gui.cp5.show();
  }
  
  public void display(){
    this.cp5.show();
  }
  
  public void hide(){
    this.cp5.hide();
  }
  
  public void scrollSongList(int length){}
}

class PracticeMain extends GUI{
  ArrayList<Song> songList;
  
  PracticeMain(PApplet thePApplet){
    super(thePApplet);
    
    //guiController.addTextfield("ds");
   
   
    cp5.addDropdownList("Practice Mode").setBarHeight(50).setWidth(1600).addItem("Practice Mode", 0).addItem("Freestyle Mode", 1).close();
    cp5.addDropdownList("All").setPosition(0,50).setBarHeight(50).setWidth(1600).addItem("All",0).addItem("Genre",1).addItem("Name",2).close();
    Button easy = cp5.addButton("EASY").setPosition(480, 805).setSize(200,90);
    Button normal = cp5.addButton("NORMAL").setPosition(690, 805).setSize(200,90);
    Button hard = cp5.addButton("HARD").setPosition(900, 805).setSize(200,90).setColorBackground(color(100,0,0)).setColorForeground(color(200,0,0)).setColorActive(color(255,0,0));
    Button start = cp5.addButton("START").setPosition(1200, 800).setSize(400,100);
    Button setting = cp5.addButton("Setting").setPosition(1500,100).setSize(100,50);
    
    //Button songplateDisplayArea = cp5.addButton("area").setPosition(0,100).setSize(1600,650);
    //songplateDisplayArea.addCallback(new SongPlateDisplayAreaListener());
    songList = new ArrayList();
    Song song = new Song(cp5, loadImage("src/003.png"), 200, 300);
    Song song2 = new Song(cp5, loadImage("src/004.png"), 700, 300);
    songList.add(song);
    songList.add(song2);
    
    //Button song = cp5.addButton("songPlate").setPosition(700,300).setImages(loadImage("src/static_songplate.png"), loadImage("src/003.png"), loadImage("src/004.png")).updateSize();
    
    setting.addCallback(new SettingButtonListener());
    start.addCallback(new StartButtonListener());
  }
  
  public void scrollSongList(int length){
    for(Song song : songList){
      song.move(length);
    }
  }
}


class PracticeGameplay extends GUI{
   PracticeGameplay(PApplet thePApplet){
    super(thePApplet);
    cp5.addDropdownList("Practice Mode - Gameplay").setBarHeight(50).setWidth(1600).close();
    Button settingPopUp = cp5.addButton("SettingPopUp").setPosition(1500,50).setSize(100,50);
    settingPopUp.addCallback(new SettingPopUpListener());
   }
}

class Setting extends GUI{
   Setting(PApplet thePApplet){
    super(thePApplet);
    cp5.addDropdownList("Setting").setBarHeight(100).setWidth(1600).close();
    Button returnBack = cp5.addButton("return").setPosition(0,0).setSize(100,100);
    Button audio = cp5.addButton("audio").setPosition(0,100).setSize(300,200);
    Button display = cp5.addButton("display").setPosition(0,300).setSize(300,200);
    Button gameplay = cp5.addButton("gameplay").setPosition(0,500).setSize(300,200);
    Button general = cp5.addButton("general").setPosition(0,700).setSize(300,200);
    Button reset = cp5.addButton("reset").setPosition(400,800).setSize(400,100);
    Button cancel = cp5.addButton("cancel").setPosition(800,800).setSize(400,100);
    Button save = cp5.addButton("save").setPosition(1200,800).setSize(400,100);
    
    returnBack.addCallback(new ConfirmSettingListener());
    audio.addCallback(new AudioButtonListener());
    display.addCallback(new DisplayButtonListener());
    gameplay.addCallback(new GameplayButtonListener());
    general.addCallback(new GeneralButtonListener());
    reset.addCallback(new ResetButtonListener());
    cancel.addCallback(new CancelButtonListener());
    save.addCallback(new SaveButtonListener());
   }
}

class AudioSetting extends GUI{
  AudioSetting(PApplet thePApplet){
    super(thePApplet);
    //Silder for general volume
    //Silder for music volume
    //Silder for sound effect volume
  }
}

class DisplaySetting extends GUI{
  DisplaySetting(PApplet thePApplet){
    super(thePApplet);
    //Drop-down Box for resolution
    //Radio Button for full screen/window
  }
}

class GameplaySetting extends GUI{
  GameplaySetting(PApplet thePApplet){
    super(thePApplet);
    //Slider for note speed
  }
}

class GeneralSetting extends GUI{
  GeneralSetting(PApplet thePApplet){
    super(thePApplet);
    //Drop-down Box for language
    //Radio Button for colorblind mode
  }
}

class SettingPopUp extends GUI{
  SettingPopUp(PApplet thePApplet){
    super(thePApplet);
    Button confirmSettingPopUp = cp5.addButton("Return").setPosition(500,500).setSize(100,100);
    cp5.addButton("Kiss my ass").setPosition(0,500).setSize(300,300);
    Button leaveGameplay = cp5.addButton("Exit").setPosition(700,500).setSize(100,100);
    confirmSettingPopUp.addCallback(new ConfirmSettingPopUpListener());
    leaveGameplay.addCallback(new LeaveGameplayListener());
    //Button for resume
    //Button for exit
    //Button for setting
  }
  
  public void display (SettingPopUp gui){
    gui.cp5.show();
  }
}
