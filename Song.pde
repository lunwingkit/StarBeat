static int seq = 0;

public class Song{
  PImage background = loadImage("src/static_songplate.png");
  AudioPlayer player;
  //Album jacket;
  int BPM;
  ArrayList<PlayLog> playLogList;
  PlayLog bestRecord;
  
  Button albumJacket;
  Textlabel songName;
  int poX;
  int poY;
  
  Song(ControlP5 cp5, PImage image, int poX, int poY){
    image(background, poX,poY);
    albumJacket = cp5.addButton("testSong" + seq).setPosition(poX, poY).setImages(image, image, image).updateSize();
    songName = cp5.addTextlabel("Song Name" + seq).setText("Vertex").setPosition(poX+80, poY+220).setColorValue(0xffffff60).setFont(createFont("Georgia",14));
    albumJacket.addCallback(new SongPlateListener());
    this.poX = poX;
    this.poY = poY;
    seq++;
  }
  
  public void move(int length){
    this.albumJacket.setPosition(poX-length,poY);
    this.songName.setPosition(poX+80-length,poY+220);
    this.poX -= length;
  }
  
}
