var Main = {
	
	 mayWinModel : null,
	mayLeftModel : null,
	mayRightModel : null,
	
	getMayWin : document.getElementById('mayWin'),
	getMayLeft : document.getElementById('mayLeft'),
	getMayRight : document.getElementById('mayRight'),
	
	
	 init: function (e) {
       
	   if(e.keyCode == 37)
	   {
	   	getMayLeft.style.display = "none";
	   	}
		
		if (e.keyCode == 39) {
			getMayRight.style.display = "none";
		}
		
	   },
	   
	   
	   
	   
   
	
Objects : function(){
	
	
	
	mayWinModel = getMayWin;
	mayLeftModel = getMayLeft;
	mayRightModel = getMayRight;
	
	if (getMayRight == null || getMayLeft == null) {
	getMayRight.style.visibility = "hidden";
	}
}


}


window.onload = Objects.init;

