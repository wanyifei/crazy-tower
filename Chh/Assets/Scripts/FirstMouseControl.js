//人物跟随鼠标移动

private var moveSpeed:int=50;//相机移动速度

var player:Transform;//定义一个人物的Transform
var playerPlane:Plane;//定义一个Plane
var cursorScreenPosition:Vector3;
var targetposition1:Vector3;
var CheckPostion:Vector3;
var i: boolean;
function Start()
{
	i=false;
	playerPlane=Plane(player.up,player.position);//在人物所在位置,以人物的Vector3.up为法线创建一个平面
	
}

function Update () 
{
	transform.position+=Vector3.right*Input.GetAxis("Mouse X")*Time.deltaTime*moveSpeed;//当鼠标平移时,相机随之平移(或右移或左移)
	transform.position+=Vector3.forward*Input.GetAxis("Mouse Y")*Time.deltaTime*moveSpeed;//当鼠标纵移时,相机随之纵移(或上移或下移)
	
	var targetposition=player.TransformPoint(Vector3(0,48.8,-30));
	transform.position=Vector3(targetposition.x,targetposition.y,targetposition.z);//相机的目标位置,这两句代码的作用是让人物一直处于相机的视野下
	
		
		if(Input.GetMouseButton(0))
		{
			cursorScreenPosition=Input.mousePosition;//鼠标在屏幕上的位置
			cursorScreenPosition.z  = 0 ;
			CheckPostion = cursorScreenPosition;
			
			StartCoroutine("PlayerMove"); //
				 
			
		}
		
	

}

//将鼠标在屏幕某一位置的坐标转化为鼠标在世界空间里该位置的坐标
function PlayerMove()
{
	cursorScreenPosition = CheckPostion;
	var ray:Ray=Camera.main.ScreenPointToRay(cursorScreenPosition);//在鼠标所在的屏幕位置发出一条射线(暂名该射线为x射线)
	var dist:float;//定义一个float变量(该变量会在下面的代码里用到)
	playerPlane.Raycast(ray,dist);//人物所在平面与x射线相交(这句代码的作用是得到x射线与人物所在平面相交时,x射线射出多远---即得到dist的值)
	targetposition1=ray.GetPoint(dist);//在x射线这条射线上,距离起点dist处的点(该点即为鼠标在世界空间里的坐标)
	while(cursorScreenPosition!=targetposition1 && i == false)
	{	
			
			player.position=Vector3.MoveTowards(player.position,targetposition1,Time.deltaTime*6);//人物坐标移动到鼠标所在世界空间的坐标
			
			yield WaitForSeconds (0.5);
			if(cursorScreenPosition==targetposition1)
			{
				i = true;
			}
			
	}
	
	
}