public class SettingButtonListener implements CallbackListener{
  
  public void controlEvent(CallbackEvent theEvent){
    switch(theEvent.getAction()){
          case(ControlP5.ACTION_PRESSED):
          println("PRESSED");
          break;
          case(ControlP5.ACTION_RELEASED):
          println("RELEASED");
          screen.display(setting);
          break;
        }
  }
}

public class StartButtonListener implements CallbackListener{
  public void controlEvent(CallbackEvent theEvent){
        switch(theEvent.getAction()){
          case(ControlP5.ACTION_PRESSED):
          println("PRESSED");
          break;
          case(ControlP5.ACTION_RELEASED):
          println("RELEASED");
          screen.display(practiceGameplay);
          break;
        }
      }
}

public class ConfirmSettingListener implements CallbackListener{
  public void controlEvent(CallbackEvent theEvent){
        switch(theEvent.getAction()){
          case(ControlP5.ACTION_PRESSED):
          println("PRESSED");
          break;
          case(ControlP5.ACTION_RELEASED):
          println("RELEASED");
          screen.display(practiceMain);
          break;
        }
      }
}

public class SettingPopUpListener implements CallbackListener{
  public void controlEvent(CallbackEvent theEvent){
        switch(theEvent.getAction()){
          case(ControlP5.ACTION_PRESSED):
          println("PRESSED");
          break;
          case(ControlP5.ACTION_RELEASED):
          println("RELEASED");
          settingPopUp.display();
          break;
        }
      }
}

public class ConfirmSettingPopUpListener implements CallbackListener{
  public void controlEvent(CallbackEvent theEvent){
        switch(theEvent.getAction()){
          case(ControlP5.ACTION_PRESSED):
          println("PRESSED");
          break;
          case(ControlP5.ACTION_RELEASED):
          println("RELEASED");
          settingPopUp.cp5.hide();
          break;
        }
      }
}

public class LeaveGameplayListener implements CallbackListener{
  public void controlEvent(CallbackEvent theEvent){
        switch(theEvent.getAction()){
          case(ControlP5.ACTION_PRESSED):
          println("PRESSED");
          break;
          case(ControlP5.ACTION_RELEASED):
          println("RELEASED");
          settingPopUp.cp5.hide();
          screen.display(practiceMain);
          break;
        }
      }
}

public class SongPlateDisplayAreaListener implements CallbackListener{
  public void controlEvent(CallbackEvent theEvent){
        switch(theEvent.getAction()){
          case(ControlP5.ACTION_PRESSED):
          println("PRESSED");
          break;
          case(ControlP5.ACTION_RELEASED):
          println("RELEASED");
          println("FUCK FUCK FUCK");
          theEvent.getController().setPosition(0,0);
          break;
          case(ControlP5.ACTION_MOVE):
          if(mouseX - pmouseX > 2)
          println("moving right");
          else if(mouseX - pmouseX < -2)
          println("moving left");
          break;
        }
  }
}

public class SongPlateListener implements CallbackListener{
  public void controlEvent(CallbackEvent theEvent){
        switch(theEvent.getAction()){
          case(ControlP5.ACTION_PRESSED):
          println("PRESSED");
          break;
          case(ControlP5.ACTION_RELEASED):
          println("RELEASED");
          break;
          case(ControlP5.ACTION_MOVE):
          println("x: " + mouseX + "  y: " + mouseY);
          break;
          case(ControlP5.ACTION_DRAG)://DOES NOT WORK
          println("D!R!A!G!I!N!G!");
          break;
        }
  }
}
