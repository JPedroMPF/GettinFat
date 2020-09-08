using System;

public abstract class SpiderJPTree {
	
	private DTBinaryDecision root = null;
    
	protected abstract DTAction Move();
	protected abstract DTAction Atack();
	protected abstract DTAction MoveToSpider();
	protected abstract DTAction Run();
	protected abstract Func<bool> SpiderEating();
	protected abstract Func<bool> RotatedToSpider();
	protected abstract Func<bool> CloseToWeb();
	protected abstract Func<bool> Eaten();
    
	
	public SpiderJPTree() {
		
		DTBinaryDecision RotatedToSpiderTree = new DTBinaryDecision(RotatedToSpider() , Atack() , Move());
		DTBinaryDecision CloseToWebTree = new DTBinaryDecision(CloseToWeb() , Run() , Move());
		DTBinaryDecision SpiderEatingTree = new DTBinaryDecision(SpiderEating() , RotatedToSpiderTree , CloseToWebTree);
		root = new DTBinaryDecision(Eaten() , MoveToSpider() , SpiderEatingTree);

		
	}
	
	public void StartTree() {
        DTAction action = root.MakeDecision();
        if( action != null) {
            action.Run();
        }
    }
}
