import React from "react";
import SpanRow from '../home/SpanRow';

function FitnessPathDetails(props) {
    const fitnessPath = props.fitnessPath;
    return (
    <div>
        <SpanRow value={fitnessPath.name} label={"Name"} name="name" />
            <SpanRow value={fitnessPath.category} label={"Category"} />
            <SpanRow value={fitnessPath.description} label={"Description"} />
            <SpanRow value={fitnessPath.body} label={"Body"} />
            <SpanRow value={fitnessPath.tags} label={"Tags"} />
      </div>
    );
    }

export default FitnessPathDetails;