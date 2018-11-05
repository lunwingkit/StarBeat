abstract class Screen{
  ControlP5 guiController;
  
  Screen(ControlP5 guiController){
    this.guiController = guiController;
  }
  public void display(){}
  
}

class PracticeMain extends Screen{
  PracticeMain(ControlP5 guiController){
    super(guiController);
  }
  
  public void display(){
    //guiController.addTextfield("ds");
   
    guiController.addDropdownList("Practice Mode").setBarHeight(50).setWidth(1600).addItem("Practice Mode", null).addItem("Freestyle Mode", null).close();
    
    
    
    guiController.addDropdownList("All").setPosition(0,50).setBarHeight(50).setWidth(1600);
    guiController.addButton("EASY").setPosition(480, 805).setSize(200,90);
    guiController.addButton("NORMAL").setPosition(690, 805).setSize(200,90);
    guiController.addButton("HARD").setPosition(900, 805).setSize(200,90);
    
    guiController.addButton("START").setPosition(1200, 800).setSize(400,100);
    //guiController.addBang("???????");
    //guiController.addAccordion("????");
    //guiController.addTab("fsdfds");
    //guiController.addToggle("fdfdsf");
    //guiController.addButtonBar("TRY").addItems(new String[]{"TRY", "TRYY"});
    //guiController.addButton("SHIT").setValue(0).setSize(400,400);
    
  }
  
  
}

class PracticeGameplay extends Screen{
   PracticeGameplay(ControlP5 guiController){
    super(guiController);
  }
  
  public void display(){
    guiController.addDropdownList("Practice Mode").setBarHeight(50).setWidth(1600).close();
   
    
  }
}

class PracticeResult extends Screen{
   PracticeResult(ControlP5 guiController){
    super(guiController);
  }
}

class Setting extends Screen{
   Setting(ControlP5 guiController){
    super(guiController);
  }
}

class FreestyleMain extends Screen{
   FreestyleMain(ControlP5 guiController){
    super(guiController);
  }
}

class FreestyleGameplay extends Screen{
   FreestyleGameplay(ControlP5 guiController){
    super(guiController);
  }
}

class FreestyleResult extends Screen{
   FreestyleResult(ControlP5 guiController){
    super(guiController);
  }
}

public void controlEvent(ControlEvent theEvent){
    println(theEvent.getController().getName());
    
    switch(theEvent.getController().getName()){
      case "START":
      println("GO!");
      break;
      case "HARD":
      println("THIS COULD BE VERY HARD!");
      break;
    }
}
