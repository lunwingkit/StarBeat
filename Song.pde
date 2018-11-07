static int seq = 0;

public class Song{
  PImage background = loadImage("src/static_songplate.png");
  AudioPlayer player;
  //Album jacket;
  int BPM;
  ArrayList<PlayLog> playLogList;
  PlayLog bestRecord;
  
  Button albumjacket;
  Textlabel songname;
  int poX;
  int poY;
  
  Song(ControlP5 cp5, PImage image, int poX, int poY){
    albumjacket = cp5.addButton("testSong" + seq).setPosition(poX, poY).setImages(loadImage("src/static_songplate.png"), image, image).updateSize().setMoveable(true);
    songname = cp5.addTextlabel("Song Name" + seq).setText("Vertex").setPosition(poX+80, poY+220).setColorValue(0xffffff60).setFont(createFont("Georgia",14));
    albumjacket.addCallback(new SongPlateListener());
    this.poX = poX;
    this.poY = poY;
    seq++;
  }
  
}
