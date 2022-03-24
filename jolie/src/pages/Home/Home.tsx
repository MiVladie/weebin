import React from 'react';

import { Helmet } from 'react-helmet';
import { useNavigate } from 'react-router-dom';
import { isMobile, openURL } from 'util/screen';

import Video from 'components/Video/Video';
import Button from 'components/Button/Button';

import logo from 'assets/icons/logo.png';

import classes from './Home.module.scss';

const Home: React.FC = () => {
	const navigate = useNavigate();

	return (
		<>
			<Helmet>
				<title>Home | Weebin</title>
			</Helmet>

			<div className={classes.Main}>
				<img className={classes.Logo} src={logo} alt='Weebin Logo' />

				<div className={classes.Container}>
					<Video
						className={classes.Trailer}
						title='Weebin Trailer'
						url='https://www.youtube.com/embed/OGZE16bhKgQ?autoplay=1&controls=0'
					/>

					<div className={classes.Actions}>
						{!isMobile() && (
							<Button onClick={() => navigate('/play')} className={classes.Play}>
								Play
							</Button>
						)}

						<Button onClick={() => openURL('https://mivladie.github.io/gato/')}>Gato</Button>
						<Button onClick={() => openURL('https://github.com/MiVladie/weebin', true)}>GitHub</Button>
					</div>
				</div>
			</div>
		</>
	);
};

export default Home;
