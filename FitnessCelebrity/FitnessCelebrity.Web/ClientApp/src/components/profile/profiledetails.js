import React from "react";
import { Link } from 'react-router-dom';

function ProfileDetails(props) {
    const profileData = props.profileData;
    return (
    <div className="card">
        <div className="card-body">
            <h5 className="card-title">{profileData.username}</h5>
            <h6 className="card-subtitle mb-2 text-muted">{profileData.firstName} {profileData.lastName}</h6>
            <p className="card-text">{profileData.description}</p>
            <Link to={'/fitnessPath/'+profileData.id} className="card-link">View</Link>
        </div>
      </div>
    );
    }

export default ProfileDetails;
