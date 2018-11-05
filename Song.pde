public class Song{
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
  
  
}
