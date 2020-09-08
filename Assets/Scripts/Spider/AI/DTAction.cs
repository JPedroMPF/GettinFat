using System;

public class DTAction : DTNode
{
	private Action action;

    public DTAction() {
            
    }

	public DTAction(Action action){
		SetAction(action);
	}

	public void SetAction(Action action){
		this.action = action;
	}

	public override DTAction MakeDecision()
	{
		return this;
	}


	public void Run()
	{
		this.action();
	}
}
