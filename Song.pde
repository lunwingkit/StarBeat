public class Song{
  PImage background = loadImage("src/static_songplate.png");
  String songName;
  String composerName;
  String chartMakerName;
  AudioPlayer player;
  //Album jacket;
  int BPM;
  ArrayList<PlayLog> playLogList;
  PlayLog bestRecord;
  
  Song(String songName, String compsoerName, String chartMakerName){
    playLogList = new ArrayList<PlayLog>();
  }
  
  Song(ControlP5 cp5){
    Button test = cp5.addButton("testSong").setPosition(700,300).setImages(loadImage("src/static_songplate.png"), loadImage("src/003.png"), loadImage("src/009.png")).updateSize().setMoveable(true);
    cp5.addTextlabel("Song Name").setText("Vertex").setPosition(750,550).setColorValue(0xffffff00).setFont(createFont("Georgia",14));
    test.addCallback(new SongPlateListener());
  }
  
}
