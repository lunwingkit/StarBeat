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
}

class PracticeMain extends GUI{
  PracticeMain(PApplet thePApplet){
    super(thePApplet);
    
    //guiController.addTextfield("ds");
   
   
    cp5.addDropdownList("Practice Mode").setBarHeight(50).setWidth(1600).addItem("Practice Mode", null).addItem("Freestyle Mode", null).close();
    cp5.addDropdownList("All").setPosition(0,50).setBarHeight(50).setWidth(1600);
    Button easy = cp5.addButton("EASY").setPosition(480, 805).setSize(200,90);
    Button normal = cp5.addButton("NORMAL").setPosition(690, 805).setSize(200,90);
    Button hard = cp5.addButton("HARD").setPosition(900, 805).setSize(200,90);
    Button start = cp5.addButton("START").setPosition(1200, 800).setSize(400,100);
    Button setting = cp5.addButton("Setting").setPosition(1500,100).setSize(100,50);
    
    Button songplateDisplayArea = cp5.addButton("area").setPosition(0,100).setSize(1600,650);
    songplateDisplayArea.addCallback(new SongPlateDisplayAreaListener());
    
    Song song = new Song(cp5);
    
    //Button song = cp5.addButton("songPlate").setPosition(700,300).setImages(loadImage("src/static_songplate.png"), loadImage("src/003.png"), loadImage("src/004.png")).updateSize();
    
    setting.addCallback(new SettingButtonListener());
    start.addCallback(new StartButtonListener());
  }
}


class PracticeGameplay extends GUI{
   PracticeGameplay(PApplet thePApplet){
    super(thePApplet);
    cp5.addDropdownList("Practice Mode - Gameplay").setBarHeight(50).setWidth(1600).close();
    Button settingPopUp = cp5.addButton("SettingPopUp").setPosition(500,500).setSize(100,100);
    settingPopUp.addCallback(new SettingPopUpListener());
   }
}

class Setting extends GUI{
   Setting(PApplet thePApplet){
    super(thePApplet);
    cp5.addDropdownList("Setting").setBarHeight(50).setWidth(1600).close();
    Button setting = cp5.addButton("SettingTest").setPosition(300,300).setSize(200,200);
    setting.addCallback(new ConfirmSettingListener());
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
  }
  
  public void display (SettingPopUp gui){
    gui.cp5.show();
  }
}
