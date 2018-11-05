public class PlayLog{
  Song song;
  double achievementRate;
  int score;
  int maxCombo;
  int flawlessCount;
  int greatCount;
  int missCount;
  
  PlayLog(Song song, int flawlessCount, int greatCount, int missCount){
    this.song = song;
    this.flawlessCount = flawlessCount;
    this.greatCount = greatCount;
    this.missCount = missCount;
    int[] count = {flawlessCount, greatCount, missCount}
    score = calculateScore(count);
    achievementRate = calculateAchievementRate(count);
  }
  
  int calculateScore(int[] count){
    int flawlessScore = 0;
    int greatScore = 0;
    int missScore = 0;
    int score = count[0]* flawlessScore + count[1]* greatScore + count[2] * missScore;
    return score;
  }
  
  double calculateAchievementRate(int[] count){
    double achievementRate = 100;
    return achievementRate;
  }
}
