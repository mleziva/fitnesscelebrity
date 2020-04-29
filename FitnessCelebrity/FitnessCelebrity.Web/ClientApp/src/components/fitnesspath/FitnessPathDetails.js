import React from "react";
import SpanRow from "../home/SpanRow";
import PrivacyEnum from "../shared/enums/PrivacyEnum";
import WorkoutScheduleEnum from "../shared/enums/WorkoutScheduleEnum";

function FitnessPathDetails(props) {
  const fitnessPath = props.fitnessPath;
  return (
    <div>
      <SpanRow value={fitnessPath.name} label={"Name"} name="name" />
      <SpanRow value={fitnessPath.createdByUserName} label={"By"} />
      <SpanRow value={fitnessPath.category} label={"Category"} />
      <SpanRow value={fitnessPath.description} label={"Description"} />
      <SpanRow value={fitnessPath.body} label={"Body"} />
      <SpanRow
        value={<PrivacyEnum value={fitnessPath.privacy} />}
        label={"privacy"}
      />
      <SpanRow
        value={<WorkoutScheduleEnum value={fitnessPath.workoutSchedule} />}
        label={"workout Schedule"}
      />
      <SpanRow value={fitnessPath.tags} label={"Tags"} />
    </div>
  );
}

export default FitnessPathDetails;
