import React, {useState} from "react";
import FitnessPathSubscriptionService from "../../services/FitnessPathSubscriptionService"

function SubscribeBtn(props) {
    const [isSubscribed, setIsSubscribed] = useState(false);
    const [FpId] = useState(props.fitnessPathId);
    //onload check subscription status
    async function SubscribeClick(){
        if(isSubscribed){
            //unsubscribe
        }
        else{
            await FitnessPathSubscriptionService.create(FpId);
        }
        setIsSubscribed(!isSubscribed)
    }
    return (
        <button className="btn btn-primary" onClick={() => SubscribeClick()}>{isSubscribed ? "Unsubscribe" : "Subscribe"}</button>
    );
    }

export default SubscribeBtn;
