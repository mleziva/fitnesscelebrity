import React from "react";

function ProfileDetails(props) {
    const profileData = props.profileData;
    return (
    <div className="card">
        <div className="card-body">
            <h5 className="card-title">{profileData.userName}</h5>
            <h6 className="card-subtitle mb-2 text-muted">{profileData.firstName} {profileData.lastName}</h6>
            <p className="card-text"> Background: {profileData.bio}</p>
            <p className="card-text">Tags: {profileData.tags}</p>
        </div>
      </div>
    );
    }

export default ProfileDetails;
